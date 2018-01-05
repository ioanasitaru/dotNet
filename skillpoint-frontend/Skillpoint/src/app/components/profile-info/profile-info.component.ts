import {Component, OnInit} from '@angular/core';
import {User} from '../../models/user';
import {isNullOrUndefined} from 'util';

@Component({
  selector: 'app-profile-info',
  templateUrl: './profile-info.component.html',
  styleUrls: ['./profile-info.component.css']
})
export class ProfileInfoComponent implements OnInit {
  constructor() {
  }

  model = new User('', '', '', '', '', '');
  passwords = true;

  ngOnInit() {
  }
  checkPasswords() {
    if (!isNullOrUndefined(this.model.password) && !isNullOrUndefined(this.model.confirmPassword)) {
      console.log(this.model.password, this.model.confirmPassword);
      this.passwords = this.model.password === this.model.confirmPassword;
    }
  }

  checkForm(form) {
    console.log(form, this.passwords);
    return form && this.passwords;
  }
}
