import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { Router } from '@angular/router';

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

  empresa = {
    nome: 'Empresa XYZ',
    userName: 'empresaXYZ',
    email: 'contato@empresaxyz.com',
    emailTruncado: 'contato@empresaxyz.com',
    DDD: '11',
    telefone: '9259-6524',
    documento: '12.345.678/0001-00',
    foto: 'assets/img/usuario.png',
    rua: 'Rua das Flores',
    numero: '123',
    complemento: '5 andar',
    bairro: 'Vila luz',
    CEP: '09876-000',
    cidade: 'São Paulo',
    estado: 'SP',
  };

  constructor(private fb: FormBuilder, private router: Router) {
    this.formulario = this.fb.group({
      nome: [this.empresa.nome],
      userName: [this.empresa.userName],
      email: [this.empresa.email],
      DDD: [this.empresa.DDD],
      telefone: [this.empresa.telefone],
      documento: [this.empresa.documento],
      rua: [this.empresa.rua],
      numero: [this.empresa.numero],
      complemento: [this.empresa.complemento],
      bairro: [this.empresa.bairro],
      CEP: [this.empresa.CEP],
      cidade: [this.empresa.cidade],
      estado: [this.empresa.estado],
    });
  }

  ngOnInit(): void {}

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
