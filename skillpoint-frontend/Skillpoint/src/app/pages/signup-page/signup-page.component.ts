import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators, FormsModule} from "@angular/forms";
import {User} from '../../model/user'

@Component({
  selector: 'app-signup-page',
  templateUrl: './signup-page.component.html',
  styleUrls: ['./signup-page.component.css']
})
export class SignupPageComponent implements OnInit {

  constructor() {
  }

  model = new User('', 'Dr IQ', '', 'Chuck Overstreet','','');

  ngOnInit() {
  }


}
