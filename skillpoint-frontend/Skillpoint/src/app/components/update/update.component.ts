import {Component, OnInit} from '@angular/core';
import {Event} from '../../models/event';
import {DataService} from '../../services/data.service';
import {EventModels} from '../../models/eventModels';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html'
})
export class UpdateComponent implements OnInit {
  eventModels: EventModels;

  constructor(private dataService: DataService) {
  }

  ngOnInit() {
  }

  get_events_eventbrite = function () {
    const eventsShort = [];

    const settings = {
      'async': false,
      'crossDomain': true,
      'url': 'https://www.eventbriteapi.com/v3/events/search/?subcategories=2002,2007,1010,2004,2005&token=XZYAN77TJCA2AIBI4A6N',
      'method': 'GET',
      'headers': {}
    };

    $.ajax(settings).done(function (data) {
      console.log(data);
      const events = data.events;
      for (let infoIndex = 0; infoIndex < events.length; infoIndex++) {
        eventsShort.push(new Event(events[infoIndex].name.text, events[infoIndex].description.text, new Date(events[infoIndex].start.local), events[infoIndex].location, events[infoIndex].logo.url, []));
      }

    });
    return eventsShort;
  };

  get_events_meetup = function () {
    const eventsShort = [];

    const settings = {
      'async': false,
      'crossDomain': true,
      'url': 'https://api.meetup.com/2/open_events?topic=softwaredev,newtech,1w&key=3311642666775f7d4b6a1c496c30613e',
      'method': 'GET',
      // 'dataType': 'jsonp',
      'headers': {}
    };

    $.ajax(settings).done(function (data) {
      const events = data.results;
      console.log(data);


      for (let infoIndex = 0; infoIndex < data.results.length; infoIndex++) {
        if (typeof events[infoIndex].description !== 'undefined') {
          let detailedLocation = '';
          if (typeof events[infoIndex].venue !== 'undefined') {
            detailedLocation = ''.concat(events[infoIndex].venue.localized_country_name).concat(', ').concat(events[infoIndex].venue.city).concat(', ').concat(events[infoIndex].venue.address_1);
          }
          else {
            detailedLocation = 'Not provided';
          }

          eventsShort.push(new Event(events[infoIndex].name, events[infoIndex].description.replace(/([\uE000-\uF8FF]|\uD83C[\uDF00-\uDFFF]|\uD83D[\uDC00-\uDDFF])/g, ''), new Date(events[infoIndex].time * 1000), detailedLocation, events[infoIndex].event_url, []));
        }
      }


    });
    console.log(eventsShort);
    return eventsShort;
  };

  get_events_hack = function () {
    const eventsShort = [];

    const settings = {
      'async': false,
      'crossDomain': true,
      'url': 'http://www.hackathonwatch.com:80/api//hackathons/coming.json?page=1',
      'method': 'GET',
      'headers': {}
    };

    $.ajax(settings).done(function (data) {
      const events = data;
      for (let infoIndex = 0; infoIndex < events.length; infoIndex++) {
        eventsShort.push(new Event(events[infoIndex].name, events[infoIndex].description, new Date(events[infoIndex].start_timestamp*1000), events[infoIndex].full_address, '', []));
      }
      console.log(eventsShort);


    });
    return eventsShort;
  };

  get_events_from_all_apis = function () {
    let eeventModels = [];
    eeventModels = eeventModels.concat(this.get_events_hack(), this.get_events_eventbrite(), this.get_events_meetup());
    this.eventModels = new EventModels(eeventModels);
    const content = 'Successfully saved!';
    $('#all').append(content);
    for (let i = 0; i < this.eventModels.eventModels.length; i++) {
      console.log(this.eventModels.eventModels[i]);
      this.eventModels.eventModels[i].tags = [
        {
          label: 'string',
          verified: true
        }
      ];
      this.dataService.postData('http://localhost:51571/api/Events', this.eventModels.eventModels[i]).subscribe(response => {
            console.log(response);
              },
              err => {
                console.log(err);
                console.log('erroare ');
              }
            );
    }
    // this.dataService.postData('http://localhost:51571/api/Events/bulk', this.eventModels.eventModels).subscribe(response => {
    //     console.log(response);
    //       },
    //       err => {
    //         console.log(err);
    //         console.log('erroare ');
    //       }
    //     );
  };

}
