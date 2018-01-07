import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import {Router} from '@angular/router';
import {HttpClient, HttpHeaders, HttpResponse} from '@angular/common/http';

@Injectable()
export class AuthenticationService {
  public token: string;

  constructor(private http: HttpClient, private router: Router) {
    // set token if saved in local storage
    const currentUser = JSON.parse(localStorage.getItem('user'));
    this.token = currentUser && currentUser.token;
  }

  login(loginModel: any): Observable<boolean> {
    console.log(loginModel);
    const headers = new HttpHeaders();
    headers.append('Content-Type', 'application/javascript');
    return this.http.post(`http://localhost:51571/auth`, loginModel, {headers: headers})
      .map((response: HttpResponse<string>) => {
        console.log('response:', response);
        // login successful if there's a jwt token in the response
        const token = 'Bearer ' + response['token'];
        const user = response['user'];
        if (token) {
          // set token property
          this.token = token;

          // store username and jwt token in local storage to keep user logged in between page refreshes
          // localStorage.setItem('currentUser', JSON.stringify(loginModel));

          localStorage.setItem('authorization', token);
          localStorage.setItem('user', JSON.stringify(user));
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
    localStorage.removeItem('user');
    localStorage.removeItem('authorization');
    this.router.navigate(['/']);
  }
}
