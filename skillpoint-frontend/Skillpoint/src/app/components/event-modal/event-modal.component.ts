import {Component, Input, OnInit} from '@angular/core';
import {EventsSectionComponent} from "../events-section/events-section.component";
import {Event} from "../../models/event";

@Component({
  selector: 'app-event-modal',
  templateUrl: './event-modal.component.html',
  styleUrls: ['./event-modal.component.css']
})
export class EventModalComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }
  @Input()event: Event

}
