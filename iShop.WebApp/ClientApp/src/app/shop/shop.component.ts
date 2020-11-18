import { Component, OnInit } from '@angular/core';
import { ShopService } from './shop.service';
import { IProduct } from '../shared/modules/product';
import { IBrand } from '../shared/modules/brands';
import { IType } from '../shared/modules/productTypes';
import { ShopParams } from '../shared/modules/shopParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  products: IProduct[];
  brands: IBrand[];
  types: IType[];
  shopParams = new ShopParams();

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
    this.shopService.getProducts(this.shopParams).subscribe(response => {
      this.products = response.data;
    }, error => {
      console.log(error);
    })
  }
  getBrands() {
    this.shopService.getBrands().subscribe(response => {
      this.brands = [{ id: 0, name: 'All' }, ...response];
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
    this.shopParams.brandId = brandId;
    this.getProduct();
  }
  onTypeSelected(typeId: number) {
    this.shopParams.typeId = typeId;
    this.getProduct()
  }
  onSortSelected(sort: string) {
    this.shopParams.sort = sort;
    this.getProduct();
  }

}
