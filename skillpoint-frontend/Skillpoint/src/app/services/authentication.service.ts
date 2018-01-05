import { Injectable } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import {Router} from '@angular/router';

@Injectable()
export class AuthenticationService {
  public token: string;

  constructor(private http: Http, private router: Router) {
    // set token if saved in local storage
    const currentUser = JSON.parse(localStorage.getItem('currentUser'));
    this.token = currentUser && currentUser.token;
  }

  login(loginModel: any): Observable<boolean> {
    console.log(loginModel);
    return this.http.post(`localhost:54554/login`, JSON.stringify(loginModel))
      .map((response: Response) => {
        console.log(response);
        // login successful if there's a jwt token in the response
        const token = response.headers.get('authorization');
        if (token) {
          // set token property
          this.token = token;

          // store username and jwt token in local storage to keep user logged in between page refreshes
          // localStorage.setItem('currentUser', JSON.stringify(loginModel));

          localStorage.setItem('authorization', token);
          // return true to indicate successful login
          return true;
        } else {
          // return false to indicate failed login
          return false;
        }
      });
  }

  logout(): void {
    // clear token remove user from local storage to log user out
    this.token = null;
    localStorage.removeItem('currentUser');
    localStorage.removeItem('authorization');
    this.router.navigate(['/']);
  }
}
