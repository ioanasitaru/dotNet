<<<<<<< HEAD
import { Component, OnInit } from '@angular/core';
=======
import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators, FormsModule} from "@angular/forms";
import {User} from '../../model/user'
>>>>>>> 3d854a135757011f980d9921afaaa10cd1a18b10

@Component({
  selector: 'app-signup-page',
  templateUrl: './signup-page.component.html',
  styleUrls: ['./signup-page.component.css']
})
export class SignupPageComponent implements OnInit {

<<<<<<< HEAD
  constructor() { }
=======
  constructor() {
  }

  model = new User('', 'Dr IQ', '', 'Chuck Overstreet','','');
>>>>>>> 3d854a135757011f980d9921afaaa10cd1a18b10

  ngOnInit() {
  }

<<<<<<< HEAD
=======

>>>>>>> 3d854a135757011f980d9921afaaa10cd1a18b10
}
