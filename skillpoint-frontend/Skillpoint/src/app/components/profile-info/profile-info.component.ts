import {Component, OnInit} from '@angular/core';
import {User} from '../../model/user';

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
    if (this.model.password && !this.model.confirmPassword) {
      this.passwords = this.model.password === this.model.confirmPassword;
    }
  }

  checkForm(form) {
    return !!(form && this.passwords);
  }

}
