import {Component, OnInit} from '@angular/core';
import {User} from '../../models/user';
import {Select2OptionData} from 'ng2-select2';

@Component({
  selector: 'app-edit-page',
  templateUrl: './edit-page.component.html',
  styleUrls: ['./edit-page.component.css']
})
export class EditPageComponent implements OnInit {
  private user: User;
  private exampleData: Array<Select2OptionData>;
  private startValue: string;
  private selected: string;

  constructor() {
  }

  ngOnInit() {
    this.user = JSON.parse(sessionStorage.getItem('user'));
    this.exampleData = [
      {
        id: '0',
        text: 'Cars',
        children: [
          {
            id: 'car1',
            text: 'Car 1'
          },
          {
            id: 'car2',
            text: 'Car 2'
          },
          {
            id: 'car3',
            text: 'Car 3'
          }
        ]
      },
      {
        id: '0',
        text: 'Planes',
        children: [
          {
            id: 'plane1',
            text: 'Plane 1'
          },
          {
            id: 'plane2',
            text: 'Plane 2'
          },
          {
            id: 'plane3',
            text: 'Plane 3'
          }
        ]
      }
    ];
    this.startValue = 'test3';
    this.selected = '';
  }

}
