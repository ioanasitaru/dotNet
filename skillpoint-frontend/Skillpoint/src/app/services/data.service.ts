import { Injectable } from '@angular/core';
import {RequestOptions, Http, Headers} from '@angular/http';

import 'rxjs/Rx';
import {Observable} from 'rxjs/Observable';
import {Router} from '@angular/router';

@Injectable()
export class DataService {

  constructor(private http2: Http) {}

  fetchData(url) {
    const options = new RequestOptions();
    options.headers = new Headers();
    options.headers.append('authorization', localStorage.getItem('authorization'));
    return this.http2.get(`${url}`, options)
      .map((res) => res.json())
      .catch((error: any) => Observable.throw(error || 'Server error'));
  }

  postData(url, jsonObject) {
    const options = new RequestOptions();
    options.headers = new Headers();
    options.headers.append('content-type', 'application/json');
    options.headers.append('authorization', localStorage.getItem('authorization'));
    this.http2.post(url, jsonObject, options).subscribe();
  }
}
