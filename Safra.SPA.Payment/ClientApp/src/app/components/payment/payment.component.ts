import { Component, OnInit } from '@angular/core';
import { PaymentService } from 'src/app/services/payment-service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {

  constructor(private paymentService: PaymentService, private route: ActivatedRoute,) { }

  totalPrice: number = 0;
  sale: any;
  saleId: string;

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.saleId = params["saleId"];
      this.GetSales();
    });
  }

  GetSales() {
    this.paymentService.GetSales(this.saleId).subscribe(
      (response) => {
        response.products.forEach(p => this.totalPrice += (p.unitPrice * p.quantity));
        this.sale = response;
      });
  }

  Pay(paymentMethod: number) {
    this.paymentService.Pay(this.saleId, paymentMethod).subscribe(
      (response) => {
        alert("Pagamento efetuado com sucesso!");
      },
      (error) => {
        alert("No momento, não é possível utilizar este método de pagamento.")
      });
  }
}
