import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Pagination } from './models/pagination';
import { Product } from './models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  products: Product[] = [];

  constructor(private http: HttpClient) {
  }
  ngOnInit(): void {
    
    this.http.get<Product[]>("http://localhost:5100/api/products")
      .subscribe((res: Product[]) => {
        this.products = res;
    });
    
  }

  title = 'client';

}
