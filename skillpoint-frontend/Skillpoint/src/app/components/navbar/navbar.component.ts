import { Component, OnInit } from '@angular/core';
import {isNullOrUndefined} from 'util';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  isUserLoggedIn = function() {
    return !isNullOrUndefined(localStorage.getItem('authorization'));
  };

  constructor() { }

  ngOnInit() {
  }
}
