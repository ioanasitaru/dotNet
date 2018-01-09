import {Component, OnInit} from '@angular/core';
import {isNullOrUndefined} from 'util';
import {AuthenticationService} from '../../services/authentication.service';
import {Router} from '@angular/router';
import {Credentials} from '../../models/credentials';
import {User} from '../../models/user';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  private user: User;
  model = new Credentials(null, null);

  constructor(private authService: AuthenticationService,
              private router: Router) {
  }

  onSubmit(loginModel: Credentials) {
    this.authService.login(loginModel).subscribe(response => {
        this.router.navigate(['/']);
      },
      err => {
        console.log(err);
        console.log('erroare ');
      }
    );
  }

  isUserLoggedIn = function () {
    return !isNullOrUndefined(localStorage.getItem('authorization'));
  };

  logout() {
    this.authService.logout();
    this.router.navigate(['/']);
  }

  ngOnInit() {
    this.user = JSON.parse(localStorage.getItem('user'));
  }
}
