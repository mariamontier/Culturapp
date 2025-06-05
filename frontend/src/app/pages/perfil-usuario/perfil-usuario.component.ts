import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { Router } from '@angular/router';
import { ClientUserResponse } from '../../models/client-user-response.model';
import { ClientUserService } from '../../services/client-user.service';

@Component({
  standalone: true,
  selector: 'app-perfil-usuario',
  templateUrl: './perfil-usuario.component.html',
  styleUrls: ['./perfil-usuario.component.css'],
  imports: [CommonModule, ReactiveFormsModule, FormsModule, RouterModule],
})
export class PerfilUsuarioComponent implements OnInit {
  formulario: FormGroup;
  abaDadosAtiva: string = 'perfil';

  usuario?: ClientUserResponse;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private clientUserService: ClientUserService
  ) {
    this.formulario = this.fb.group({
      nome: [this.usuario?.fullName],
      userName: [this.usuario?.userName],
      telefone: [this.usuario?.phoneResponse],
      documento: [this.usuario?.cpf],
      endereco: [this.usuario?.addressResponse],
    });
  }

  ngOnInit(): void {
    const usuarioId = 10; // Substitua pelo ID do usuário logado
    this.getUsuarioLogado(usuarioId);
  }

  getUsuarioLogado(id: number): void {
    this.clientUserService.getClientUserById(id).subscribe({
      next: (usuario) => {
        this.usuario = usuario;
        this.formulario.patchValue({
          nome: usuario.fullName,
          userName: usuario.userName,
          telefone: usuario.phoneResponse,
          documento: usuario.cpf,
          endereco: usuario.addressResponse,
        });
      }
    });
  }

  mudarAbaDados(aba: string): void {
    this.abaDadosAtiva = aba;
  }

  salvarDados(): void {
    if (this.formulario.valid) {
      console.log('Dados salvos:', this.formulario.value);
      this.usuario = { ...this.usuario, ...this.formulario.value };
    }
  }

  sair(): void {
    console.log('Usuário saiu do sistema');
    // Aqui você pode adicionar a lógica de logout
  }

  eventos = [
    {
      nome: 'Angular Conf 2024',
      descricao: 'Evento sobre Angular e boas práticas',
      status: 'Concluído',
    },
    {
      nome: 'Semana Dev Frontend',
      descricao: 'Palestras sobre UI/UX e tendências',
      status: 'Em andamento',
    },
    {
      nome: 'Hackathon SP',
      descricao: 'Maratona de programação de 48h',
      status: 'Inscrito',
    },
  ];
}
