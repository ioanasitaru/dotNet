import {Component, Input, OnInit} from '@angular/core';
import {EventDTO} from "../../models/eventDTO";
import {Router} from "@angular/router";

@Component({
  selector: 'app-event-generic',
  templateUrl: './event-generic.component.html',
  styleUrls: ['./event-generic.component.css']
})
export class EventGenericComponent implements OnInit {

  currentUrl: string;

  constructor(private router: Router) {
  }

  @Input() events: Array<EventDTO>;

  ngOnInit() {
    this.currentUrl = this.router.url;

  }

}
