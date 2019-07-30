import { Component, Inject } from '@angular/core';
import { FormGroup, Validators, FormControl, FormBuilder } from '@angular/forms';
import { Router, ActivatedRoute, Route } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Category } from '../models/category.model';

@Component({
  selector: 'add-category',
  templateUrl: './AddCategory.component.html'
})
export class AddCategoryComponent {
  CategoryForm: FormGroup;
  category: Category;
  _http: HttpClient;
  _myUrl: string;
  stt: any;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string,
    private _fb: FormBuilder, private _avRoute: ActivatedRoute, private _route: Router) {
    this._http = http;
    this._myUrl = baseUrl;

    this.CategoryForm = this._fb.group({
      ID: ['', [Validators.required]],
      Title: ['', [Validators.required]],
      Status: ['', [Validators.required]]
    })
  }

  save() {
    if (!this.CategoryForm.valid) {
      return;
    }
    this._http.post<Category>(this._myUrl + 'api/Category/AddCategory/', this.CategoryForm.getRawValue())
      .subscribe(rs => { this.stt = rs }, error => console.error(error));
  }

  cancel() {
    console.log("Click cancel button");
  }

  get ID() { return this.CategoryForm.get('ID'); }
  get Title() { return this.CategoryForm.get('Title'); }
  get Status() { return this.CategoryForm.get('Status'); }
}
