import {Component, OnInit} from '@angular/core';
import {DataService} from '../../services/data.service';
import {EventDTO} from "../../models/eventDTO";

@Component({
  selector: 'app-events-section',
  templateUrl: './events-section.component.html',
  styleUrls: ['./events-section.component.css']
})
export class EventsSectionComponent implements OnInit {
  private events: Array<EventDTO>;

  constructor(private dataService: DataService) {
  }

  ngOnInit() {
    if (sessionStorage.getItem('authorization') == null) {
      this.dataService.fetchData('http://localhost:51571/api/Events/Future').subscribe(
        response => {
          console.log(response);
          this.events = response;
        },
        error => {
          console.log(error);
        }
      );
    }
    else {
      this.dataService.fetchData('http://localhost:51571/api/Events').subscribe(
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
}
