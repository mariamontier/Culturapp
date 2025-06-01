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
    nome: 'Paula Fernandes Jacobina',
    userName: 'paulafernandes',
    email: 'paulafernandes@gmail.com',
    emailTruncado: 'paulafernandes@gm....',
    telefone: '17 9999-9999',
    documento: '0000',
    nascimento: '28-01-1988',
    foto: 'assets/img/usuario.png',
    endereco: 'Rua das Flores, 123, São Paulo, SP',
  };

  constructor(private fb: FormBuilder, private router: Router) {
    this.formulario = this.fb.group({
      nome: [this.empresa.nome],
      userName: [this.empresa.userName],
      email: [this.empresa.email],
      telefone: [this.empresa.telefone],
      documento: [this.empresa.documento],
      nascimento: [this.empresa.nascimento],
      endereco: [this.empresa.endereco],
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
