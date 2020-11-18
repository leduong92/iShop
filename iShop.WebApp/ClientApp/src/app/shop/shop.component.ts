import { Component, OnInit } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { ShopService } from './shop.service';
import { IBrand } from '../shared/models/brands';
import { IType } from '../shared/models/productTypes';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {

  products: IProduct[];
  brands: IBrand[];
  types: IType[];
  brandIdSelected = 0;
  typeIdSelected = 0;
  sortSelected = 'name';
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price: Low to High', value: 'priceAsc' },
    { name: 'Price: High to Low', value: 'PriceDesc' },
  ]

  constructor(private shopService: ShopService) { }

  ngOnInit() {
    this.getProduct();
    this.getBrands();
    this.getTypes();
  }

  getProduct() {
    this.shopService.getProducts(this.brandIdSelected, this.typeIdSelected, this.sortSelected).subscribe(response => {
      this.products = response.data;
    }, error => {
      console.log(error);
    })
  }
  getBrands() {
    this.shopService.getBrands().subscribe(response => {
      this.brands = [{id: 0, name: 'All'}, ...response];
    }, error => {
      console.log(error);
    })
  }
  getTypes() {
    this.shopService.getTypes().subscribe(response => {
      this.types = [{ id: 0, name: 'All' }, ...response];
    }, error => {
      console.log(error);
    })
  }


  onBrandSelected(brandId: number) {
    this.brandIdSelected = brandId;
    this.getProduct();
  }
  onTypeSelected(typeId: number) {
    this.typeIdSelected = typeId;
    this.getProduct()
  }
  onSortSelected(sort: string) {
    this.sortSelected = sort;
    this.getProduct();
  }

}
