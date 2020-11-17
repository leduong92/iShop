import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { error } from '@angular/compiler/src/util';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'iShop App';
  products: any[];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    
    this.http.get("https://localhost:5001/api/products?pageSize=50").subscribe((Response: any) => {
      this.products = Response.data;
      console.log(this.products);
    }, error => {
        console.log(error);
    });
  }
}
