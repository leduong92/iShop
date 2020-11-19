import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { map, delay } from 'rxjs/operators';

import { IBrand } from '../shared/modules/brands';
import { IType } from '../shared/modules/productTypes';
import { IPagination } from '../shared/modules/pagination';
import { ShopParams } from '../shared/modules/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getProducts(shopParams: ShopParams) {
    let params = new HttpParams();

    if (shopParams.brandId !== 0) {
      params = params.append('brandId', shopParams.brandId.toString());
    }
    if (shopParams.typeId !== 0) {
      params = params.append('typeId', shopParams.typeId.toString());
    }
    //search
    if (shopParams.search) {
      params = params.append('search', shopParams.search);
    }
    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageSize', shopParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'products', { observe: 'response', params })
      .pipe(
        //delay(1000),
        map(response => {
          return response.body;
        })
      );
  };

  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands');
  };

  getTypes() {
    return this.http.get<IType[]>(this.baseUrl + 'products/types');
  }

}
