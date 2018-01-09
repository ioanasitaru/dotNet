import {Component, OnInit} from '@angular/core';
import $ from '';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html'
})
export class UpdateComponent implements OnInit {

  constructor() {
  }

  ngOnInit() {
  }

  get_events_eventbrite = function () {
    const settings = {
      'async': true,
      'crossDomain': true,
      'url': 'https://www.eventbriteapi.com/v3/events/search/?subcategories=2002,2007,1010,2004,2005&token=XZYAN77TJCA2AIBI4A6N',
      'method': 'GET',
      'headers': {}
    }

    $.ajax(settings).done(function (data) {
      console.log(data);
      const events = data.events;
      const eventsShort = [];
      const event = function (name, description, location, date_and_time, url, img) {
        this.name = name;
        this.description = description;
        this.location = location;
        this.date_and_time = date_and_time;
        this.url = url;
        this.img = img;
      }
      for (let infoIndex = 0; infoIndex < events.length; infoIndex++) {
        eventsShort.push(new event(events[infoIndex].name.text, events[infoIndex].description.text, events[infoIndex].location, events[infoIndex].start.local, events[infoIndex].url, events[infoIndex].logo.url));
      }
      console.log(eventsShort);
      $.ajaxSetup({
        headers: {
          'X-CSRF-TOKEN': $('meta[name="csrf-token"]').attr('content')
        }
      });
      $.ajax({
        type: 'POST',
        url: 'storeEvent',
        dataType: 'json',
        data: {'events': eventsShort, 'source': 'Eventbrite'},
        success: function (response) {
          console.log('All good!');
          console.log(response);
        },
        error: function (xhr, ajaxOptions, thrownError) {
          console.log(xhr.status);
          console.log(xhr.responseText);
          console.log(thrownError);
        }
      });
    });
  }

  get_events_meetup = function () {
    const settings = {
      'async': true,
      'crossDomain': true,
      'url': 'https://api.meetup.com/2/open_events?topic=softwaredev,newtech,1w&key=3311642666775f7d4b6a1c496c30613e',
      'method': 'GET',
      'dataType': 'jsonp',
      'headers': {}
    }

    $.ajax(settings).done(function (data) {
      console.log(data);
      const events = data.results;
      const eventsShort = [];
      const event = function (name, description, location, date_and_time, url, img) {
        this.name = name;
        this.description = description;
        this.location = location;
        this.date_and_time = date_and_time;
        this.url = url;
        this.img = img;
      }


      for (let infoIndex = 0; infoIndex < data.results.length; infoIndex++) {
        if (typeof events[infoIndex].description !== 'undefined') {
          let detailedLocation = '';
          if (typeof events[infoIndex].venue !== 'undefined') {
            detailedLocation = ''.concat(events[infoIndex].venue.localized_country_name).concat(', ').concat(events[infoIndex].venue.city).concat(', ').concat(events[infoIndex].venue.address_1);
          }
          else {
            detailedLocation = 'Not provided';
          }
          console.log(detailedLocation);

          eventsShort.push(new event(events[infoIndex].name, events[infoIndex].description.replace(/([\uE000-\uF8FF]|\uD83C[\uDF00-\uDFFF]|\uD83D[\uDC00-\uDDFF])/g, ''), detailedLocation, events[infoIndex].time / 1000, events[infoIndex].event_url, null));
          console.log(eventsShort[infoIndex]);
        }
      }

      console.log(eventsShort);
      $.ajaxSetup({
        headers: {
          'X-CSRF-TOKEN': $('meta[name="csrf-token"]').attr('content')
        }
      });
      $.ajax({
        type: 'POST',
        url: 'storeEvent',
        dataType: 'json',
        data: {'events': eventsShort, 'source': 'Meetup'},
        success: function (response) {
          console.log('All good!');
          console.log(response);
        },
        error: function (xhr, ajaxOptions, thrownError) {
          console.log(xhr.status);
          console.log(xhr.responseText);
          console.log(thrownError);
        }
      });
    });
  };

  get_events_hack = function () {
    const settings = {
      'async': true,
      'crossDomain': true,
      'url': 'http://www.hackathonwatch.com:80/api//hackathons/coming.json?page=1',
      'method': 'GET',
      'headers': {}
    }

    $.ajax(settings).done(function (data) {
      console.log(data);
      const events = data;
      const eventsShort = [];
      const event = function (name, description, location, date_and_time, url) {
        this.name = name;
        this.description = description;
        this.location = location;
        this.date_and_time = date_and_time;
        this.url = url;
      }
      for (let infoIndex = 0; infoIndex < events.length; infoIndex++) {
        eventsShort.push(new event(events[infoIndex].name, events[infoIndex].description, events[infoIndex].full_address, events[infoIndex].start_timestamp, events[infoIndex].public_url));
      }
      $.ajaxSetup({
        headers: {
          'X-CSRF-TOKEN': $('meta[name="csrf-token"]').attr('content')
        }
      });
      $.ajax({
        type: 'POST',
        url: 'storeEvent',
        dataType: 'json',
        data: {'events': eventsShort, 'source': 'Hackathon'},
        success: function (response) {
          console.log('All good!');
          console.log(response);
        },
        error: function (xhr, ajaxOptions, thrownError) {
          console.log(xhr.status);
          console.log(xhr.responseText);
          console.log(thrownError);
        }
      });
    });
  };


}
