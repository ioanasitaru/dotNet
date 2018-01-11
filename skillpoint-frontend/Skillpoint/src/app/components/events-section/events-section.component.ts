import { Component, OnInit } from '@angular/core';
import {DataService} from '../../services/data.service';

@Component({
  selector: 'app-events-section',
  templateUrl: './events-section.component.html',
  styleUrls: ['./events-section.component.css']
})
export class EventsSectionComponent implements OnInit {
  private events: Array<Event>
  constructor(private dataService: DataService) { }

  ngOnInit() {
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
