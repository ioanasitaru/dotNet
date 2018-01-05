import { Injectable } from '@angular/core';
import {RequestOptions, Headers} from '@angular/http';

import 'rxjs/Rx';
import {Observable} from 'rxjs/Observable';
import {Router} from '@angular/router';
import {HttpClient, HttpHeaders, HttpRequest} from '@angular/common/http';

@Injectable()
export class DataService {

  constructor(private http: HttpClient) {}

  fetchData(url) {
    const headers = new HttpHeaders();
    headers.append('authorization', localStorage.getItem('authorization'));
    const request = new HttpRequest(null, null, null, {headers: headers});
    return this.http.get(`${url}`)
      // .map((res) => res.json())
      .catch((error: any) => Observable.throw(error || 'Server error'));
  }

  // postData(url, jsonObject) {
  //   const options = new RequestOptions();
  //   options.headers = new Headers();
  //   options.headers.append('content-type', 'application/json');
  //   options.headers.append('authorization', localStorage.getItem('authorization'));
  //   this.http.post(url, jsonObject, options).subscribe();
  // }
}
