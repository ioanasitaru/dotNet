import { Injectable } from '@angular/core';
import {RequestOptions, Headers} from '@angular/http';

import 'rxjs/Rx';
import {Observable} from 'rxjs/Observable';
import {Router} from '@angular/router';
import {HttpClient, HttpHeaders, HttpRequest} from '@angular/common/http';
import {isNullOrUndefined} from "util";

@Injectable()
export class DataService {

  constructor(private http: HttpClient) {}

  fetchData(url) {
    const headers = new HttpHeaders();
    headers.append('authorization', localStorage.getItem('authorization'));
    return this.http.get(`${url}`)
      // .map((res) => res.json())
      .catch((error: any) => Observable.throw(error || 'Server error'));
  }

  postData(url, jsonObject) {
    const headers = new HttpHeaders();
    if (localStorage.getItem('authorization') !== '') {
      headers.append('authorization', localStorage.getItem('authorization'));
    }
    return this.http.post(url, jsonObject);
  }
}
