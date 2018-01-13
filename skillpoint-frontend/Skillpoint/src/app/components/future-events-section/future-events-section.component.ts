import { Component, OnInit } from '@angular/core';
import {DataService} from "../../services/data.service";
import {Event} from "../../models/event";

@Component({
  selector: 'app-future-events-section',
  templateUrl: './future-events-section.component.html',
  styleUrls: ['./future-events-section.component.css']
})
export class FutureEventsSectionComponent implements OnInit {

  constructor(private dataService: DataService) { }
  events: Array<Event>;

  ngOnInit() {
    this.dataService.fetchData(`http://localhost:51571/AttendedFutureEvents/${JSON.parse(sessionStorage.getItem('user')).id}`).subscribe(
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
