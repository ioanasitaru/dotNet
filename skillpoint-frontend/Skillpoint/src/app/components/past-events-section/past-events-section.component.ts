import {Component, OnInit} from '@angular/core';
import {Event} from "../../models/event";
import {DataService} from "../../services/data.service";
import {isNullOrUndefined} from "util";

@Component({
  selector: 'app-past-events-section',
  templateUrl: './past-events-section.component.html',
  styleUrls: ['./past-events-section.component.css']
})
export class PastEventsSectionComponent implements OnInit {

  constructor(private dataService: DataService) {
  }
  isNull: boolean;
  events: Array<Event>;

  ngOnInit() {
    this.isNull = isNullOrUndefined(this.events);
    this.dataService.fetchData(`http://localhost:51571/PastEvents/${JSON.parse(sessionStorage.getItem('user')).id}`).subscribe(
      response => {
        console.log(response);
        this.events = response;
        console.log(this.events);

      },
      error => {
        console.log(error);
      }
    );
  }

}
