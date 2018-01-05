import {Component, OnInit} from '@angular/core';
import {User} from "../../model/user";

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

  checkPasswords(){
    if(this.model.password != NaN && this.model.confirmPassword != NaN){
      if(this.model.password !== this.model.confirmPassword){
        this.passwords = false;
      }
      else{
        this.passwords = true;
      }
    }
  }

  checkForm(form){
    if(form && this.passwords){
      return true;
    }
    return false;
  }
}
