import {Component, OnInit} from '@angular/core';
import {User} from '../../models/user';
import {Select2OptionData} from 'ng2-select2';
import {DataService} from "../../services/data.service";
import {Tag} from "../../models/tag";
import {forEach} from "@angular/router/src/utils/collection";
import {Router} from "@angular/router";

@Component({
  selector: 'app-edit-page',
  templateUrl: './edit-page.component.html',
  styleUrls: ['./edit-page.component.css']
})
export class EditPageComponent implements OnInit {
  private user: User;
  private tags: Array<Tag>;
  private selected: string;
  private selectedTags: any;


  constructor(private dataService: DataService, private router: Router) {
  }

  ngOnInit() {
    eval (' $(\'.select2-multi\').select2({ tags: true, placeholder: "Interests (e.g. C++, java)" }); ');

    this.tags = [];
    // this.selectedTags = [];
    this.user = JSON.parse(sessionStorage.getItem('user'));
    console.log(this.user.tags);
    this.dataService.fetchData('http://localhost:51571/api/Tags').subscribe(
      response => {
        let databaseTags = this.user.tags.map(tag => tag.label)
        for (let tag of response) {

          if (databaseTags.indexOf(tag.label) > -1) {
          }
          else {
            this.tags.push(new Tag(tag.label, tag.verified));
          }
        }
        console.log(this.tags);
      },
      error => {
        console.log(error);
      }
    );


    this.selected = '';
  }


  onSubmit(user) {
    user.tags = this.getTags();
    this.dataService.putData(`http://localhost:51571/api/Users/${JSON.parse(sessionStorage.getItem('user')).id}`, user).subscribe(response => {
        this.router.navigate(['/profile'])
      },
      err => {
        console.log(err);
        console.log('erroare ');
      }
    );

  }


  getTags() {

    let tags_label = document.getElementsByClassName('select2-selection__choice');
    let tags = []
    for (let i = 0; i < tags_label.length; i++) {
      tags.push(tags_label[i].innerHTML.replace('<span class="select2-selection__choice__remove" role="presentation">×</span>', ''));
    }
    let db_tags = this.tags.map(tag => tag.label)
    let finalListOfFuckingTags = [];
    for (let tag of tags) {
      finalListOfFuckingTags.push(new Tag(tag, db_tags.indexOf(tag) > -1));
    }
    return finalListOfFuckingTags;
  }


}
