import {Component, Input, OnInit} from '@angular/core';
import {EventDTO} from "../../models/eventDTO";

@Component({
  selector: 'app-event-generic',
  templateUrl: './event-generic.component.html',
  styleUrls: ['./event-generic.component.css']
})
export class EventGenericComponent implements OnInit {

  constructor() { }

  @Input()events: Array<EventDTO>;

  ngOnInit() {
  }

}
