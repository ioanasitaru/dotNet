import { Injectable } from '@angular/core';
import 'rxjs/Rx';
import {Observable} from 'rxjs/Observable';
import {HttpClient, HttpHeaders} from '@angular/common/http';

@Injectable()
export class DataService {

  constructor(private http: HttpClient) {}

  fetchData(url) {
    const headers = new HttpHeaders();
    headers.append('authorization', sessionStorage.getItem('authorization'));
    return this.http.get(`${url}`)
      // .map((res) => res.json())
      .catch((error: any) => Observable.throw(error || 'Server error'));
  }

  postData(url, jsonObject) {
    console.log("se intampla");
    let headers = new HttpHeaders();
    if (sessionStorage.getItem('authorization') !== '') {
      headers.append('authorization', sessionStorage.getItem('authorization'));
    }
    headers = headers.append('Content-Type', 'application/json');
    return this.http.post(url, jsonObject, {headers: headers}).catch((error: any) => Observable.throw(error || 'Server error'));
  }
  putData(url, jsonObject) {
    console.log("se intampla");
    let headers = new HttpHeaders();
    if (sessionStorage.getItem('authorization') !== '') {
      headers.append('authorization', sessionStorage.getItem('authorization'));
    }
    headers = headers.append('Content-Type', 'application/json');
    return this.http.put(url, jsonObject, {headers: headers}).catch((error: any) => Observable.throw(error || 'Server error'));
  }
}
