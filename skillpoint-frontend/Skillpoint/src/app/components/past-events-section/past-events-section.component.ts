import { Component, OnInit } from '@angular/core';
import {Event} from "../../models/event";
import {DataService} from "../../services/data.service";

@Component({
  selector: 'app-past-events-section',
  templateUrl: './past-events-section.component.html',
  styleUrls: ['./past-events-section.component.css']
})
export class PastEventsSectionComponent implements OnInit {

  constructor(private dataService: DataService) { }
  events: Array<Event>;

  ngOnInit() {
    this.dataService.fetchData(`http://localhost:51571/PastEvents/${JSON.parse(sessionStorage.getItem('user')).id}`).subscribe(
        response => {
          console.log(response);
          this.events = response;
        },
        error => {
          console.log(error);
        }
      );
  }

}
