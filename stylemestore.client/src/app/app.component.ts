import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IProductItem, IProductResponse } from './interfaces';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  public productItems: IProductItem[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getProductItems();
  }

  getProductItems() {
    this.http.get<IProductResponse>('https://localhost:7009/ProductItems').subscribe(
      (result) => {
        this.productItems = result.productItems;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'Style Me Store';
}
