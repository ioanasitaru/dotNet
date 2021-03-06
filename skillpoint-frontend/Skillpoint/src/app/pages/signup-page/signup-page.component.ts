import {Component} from '@angular/core';
import {User} from '../../models/user';
import {Router} from '@angular/router';
import {DataService} from '../../services/data.service';
import {isNullOrUndefined} from 'util';

@Component({
  selector: 'app-signup-page',
  templateUrl: './signup-page.component.html',
  styleUrls: ['./signup-page.component.css']
})
export class SignupPageComponent {
  model = new User(null, null, null, null, null, null);
  passwords = false;
  constructor(private dataService: DataService,
              private router: Router) { }
  onSubmit(signupModel: User) {
    console.log(signupModel);
    this.dataService.postData('http://localhost:51571/api/users', signupModel).subscribe(response => {
        this.router.navigate(['/']);
      },
      err => {
        console.log(err);
        console.log('erroare ');
      }
    );
  }
  checkPasswords() {
    console.log(this.model.password, this.model.confirmPassword, this.passwords);
    if (!isNullOrUndefined(this.model.password) && !isNullOrUndefined(this.model.confirmPassword)) {
      this.passwords = this.model.password === this.model.confirmPassword;
    } else {
      this.passwords = false;
    }
  }
}
