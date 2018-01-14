import {Component, Input, OnInit} from '@angular/core';
import {EventsSectionComponent} from "../events-section/events-section.component";
import {Event} from "../../models/event";
import {DataService} from "../../services/data.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-event-modal',
  templateUrl: './event-modal.component.html',
  styleUrls: ['./event-modal.component.css']
})
export class EventModalComponent implements OnInit {

  constructor(private dataService: DataService, private router: Router) {
  }

  currentUrl: string;
  dateTimeNow: Date;
  ngOnInit() {
     this.currentUrl = this.router.url;
     this.dateTimeNow = new Date(Date.now());
     console.log(this.currentUrl);
  }

  @Input() event: Event
  @Input() events;

  ToggleStatus(event_id) {

    let user_id = JSON.parse(sessionStorage.getItem('user')).id;
    this.dataService.postData(`http://localhost:51571/Attend/${event_id}`, {
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
    for(let event of this.events){
      if(event.id == event_id){
        this.events.splice(this.events.indexOf(event), 1);
        console.log(this.events);
        break;
      }
    }
  }
}
