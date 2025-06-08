import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { Router } from '@angular/router';
import { EnterpriseUserResponse } from '../../models/enterprise-user-response.model';

@Component({
  standalone: true,
  selector: 'app-perfil-empresa',
  templateUrl: './perfil-empresa.component.html',
  styleUrls: ['./perfil-empresa.component.css'],
  imports: [CommonModule, ReactiveFormsModule, FormsModule, RouterModule],
})
export class PerfilEmpresaComponent implements OnInit {
  formulario: FormGroup;
  abaDadosAtiva: string = 'perfil';

  empresa?: EnterpriseUserResponse;

  constructor(private fb: FormBuilder, private router: Router) {
    this.formulario = this.fb.group({
      userName: [this.empresa?.UserName],
      fullName: [this.empresa?.FullName],
      email: [this.empresa?.email],
      areaCode: [this.empresa?.phones?.[0]?.areaCode],
      phoneNumber: [this.empresa?.phones?.[0]?.phoneNumber],
      cnpj: [this.empresa?.cnpj],
      street: [this.empresa?.address?.street],
      number: [this.empresa?.address?.number],
      complement: [this.empresa?.address?.complement],
      neighborhood: [this.empresa?.address?.neighborhood],
      zipCode: [this.empresa?.address?.zipCode],
      city: [this.empresa?.address?.city],
      state: [this.empresa?.address?.state],
    });
  }

  ngOnInit(): void { }

  mudarAbaDados(aba: string): void {
    this.abaDadosAtiva = aba;
  }

  salvarDados(): void {
    if (this.formulario.valid) {
      console.log('Dados salvos:', this.formulario.value);
      this.empresa = { ...this.empresa, ...this.formulario.value };
    }
  }

  editarEvento(id: number) {
    this.router.navigate(['/editar-evento'], { queryParams: { id } });
  }

  eventos = [
    {
      id: 1,
      nome: 'Angular Conf 2024',
      descricao: 'Evento sobre Angular e boas práticas',
      status: 'Concluído',
    },
    {
      id: 2,
      nome: 'Semana Dev Frontend',
      descricao: 'Palestras sobre UI/UX e tendências',
      status: 'Em andamento',
    },
    {
      id: 3,
      nome: 'Hackathon SP',
      descricao: 'Maratona de programação de 48h',
      status: 'Inscrito',
    },
  ];
}
