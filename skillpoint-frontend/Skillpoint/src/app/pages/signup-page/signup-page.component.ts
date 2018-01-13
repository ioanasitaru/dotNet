import {Component, OnInit} from '@angular/core';
import {User} from '../../models/user';
import {Router} from '@angular/router';
import {DataService} from '../../services/data.service';
import {isNullOrUndefined} from 'util';
import {AuthenticationService} from '../../services/authentication.service';
import {Credentials} from '../../models/credentials';
import {Tag} from "../../models/tag";


@Component({
  selector: 'app-signup-page',
  templateUrl: './signup-page.component.html',
  styleUrls: ['./signup-page.component.css']
})
export class SignupPageComponent implements OnInit{
  ngOnInit(): void {
    this.dataService.fetchData('http://localhost:51571/api/Tags').subscribe(
        response => {
          for (let tag of response){
            this.tags.push(new Tag(tag.label, tag.verified));
          }
          console.log(this.tags);
        },
        error => {
          console.log(error);
        }
      );
  }
  model = new User(null, null, null, null, null, null, null);
  passwords = false;
  tags = [];
  constructor(private authService: AuthenticationService,
              private dataService: DataService,
              private router: Router) { }



  checkPasswords() {
    console.log(this.model.password, this.model.confirmPassword, this.passwords);
    if (!isNullOrUndefined(this.model.password) && !isNullOrUndefined(this.model.confirmPassword)) {
      this.passwords = this.model.password === this.model.confirmPassword;
    } else {
      this.passwords = false;
    }
  }

  getTags(){

    let tags_label= document.getElementsByClassName('select2-selection__choice');
    let tags = []
    for(let i=0; i<tags_label.length; i++){
      tags.push(tags_label[i].innerHTML.replace('<span class="select2-selection__choice__remove" role="presentation">×</span>', ''));
    }
    let db_tags = this.tags.map(tag => tag.label)
    let finalListOfFuckingTags = [];
    for(let tag of tags){
        finalListOfFuckingTags.push(new Tag(tag, tag in db_tags));
        }
    return finalListOfFuckingTags;
  }

  onSubmit(user){
    user.tags = this.getTags();
    this.dataService.postData('http://localhost:51571/api/users', user).subscribe(response => {
        this.authService.login(new Credentials(user.username, user.password)).subscribe(resp => {
            this.router.navigate(['/']);
          },
          err => {
            console.log(err);
            console.log('erroare ');
          }
        );
      },
      err => {
        console.log(err);
        console.log('erroare ');
      }
    );}


}
