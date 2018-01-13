import {Component, Input, OnInit} from '@angular/core';
import {EventsSectionComponent} from "../events-section/events-section.component";
import {Event} from "../../models/event";
import {DataService} from "../../services/data.service";

@Component({
  selector: 'app-event-modal',
  templateUrl: './event-modal.component.html',
  styleUrls: ['./event-modal.component.css']
})
export class EventModalComponent implements OnInit {

  constructor(private dataService: DataService) {
  }

  ngOnInit() {
  }

  @Input() event: Event

  ToggleStatus(event_id) {
    let user_id = JSON.parse(sessionStorage.getItem('user')).id;
    this.dataService.postData(`http://localhost:51571/Attend/${user_id}`, {
      userId: user_id,
      eventId: event_id
    }).subscribe(response => {
        console.log(response);
      },
      err => {
        console.log(err);
        console.log('erroare ');
      }
    );
  }
}
