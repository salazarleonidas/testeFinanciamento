import { Component, OnInit } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Financiamento } from '../shared//models/financiamento';
import { FinanciamentoHttpService } from '../services/http/financiamento.http-service';

@Component({
  selector: 'app-financiamento',
  templateUrl: './financiamento.component.html',
  styleUrls: ['./financiamento.component.css'],
  providers: [FinanciamentoHttpService],
})
export class FinanciamentoComponent implements OnInit {
  financiamentoForm: FormGroup;
  model: Financiamento = new Financiamento; 
  submittedModel: Financiamento = new Financiamento; 
  submitted: boolean = false;
  tipos: string[];

  constructor(private formBuilder: FormBuilder, 
              private httpService : FinanciamentoHttpService){
    this.tipos = ['Direto', 'Consignado', 'Imobiliário',
                'Pessoa Física', 'Pessoa Jurídica'];   

    this.financiamentoForm = this.formBuilder.group({
      valor: [this.model.Valor, Validators.required],
      tipo: [this.model.Tipo, Validators.required],
      dataPrimeiraParcela: [this.model.DataPrimeiraParcela, Validators.required],
      quantidadeParcelas: [this.model.QuantidadeParcelas, Validators.required]
    });
  }

  ngOnInit(): void {
  }

  onSubmit({ value, valid }: { value: Financiamento, valid: boolean }) {
    this.httpService.requisitar(value).subscribe({
      next: (response) => {
        console.log("Sucesso");
        console.log(response);
        this.submitted = true;
        this.submittedModel = response;
      },
      error: (err) => {
        console.log("Erro");
        console.log(err);
      }, 
      complete: () => {}
    });
  }

  novaRequisicao(){
    this.submitted = false;
    this.model = new Financiamento;
    this.submittedModel = new Financiamento;
  }
}
