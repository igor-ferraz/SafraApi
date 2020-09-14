import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  constructor(private httpClient: HttpClient) { }

  private server: string = "http://localhost:54671";
  private paymentPrefix: string = "api/v1/payment";
  private salePrefix: string = "api/v1/sale";

  GetSales(id: string): Observable<any> {
    let url = `${this.server}/${this.salePrefix}/${id}`;
    return this.httpClient.get(url);
  }

  Pay(saleId: string, paymentMethod: number): Observable<any> {
    let url = `${this.server}/${this.salePrefix}/${saleId}/paymentMethod/${paymentMethod}`;
    return this.httpClient.get(url);
  }
}
