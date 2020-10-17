import { Component, OnInit, OnDestroy, TemplateRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProfessorService } from 'src/app/services/professor.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { Professor } from 'src/app/models/Professor';
import { AlunoService } from 'src/app/services/aluno.service';
import { Aluno } from 'src/app/models/Aluno';

@Component({
  selector: 'app-professor-detalhe',
  templateUrl: './professor-detalhe.component.html',
  styleUrls: ['./professor-detalhe.component.css']
})
export class ProfessorDetalheComponent implements OnInit, OnDestroy {

  public modalRef: BsModalRef;
  public professorSelecionado: Professor;
  public titulo = '';
  public alunosProfs: Aluno[];
  private unsubscriber = new Subject();

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private professorService: ProfessorService,
    private alunoService: AlunoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
  ) { }

  openModal(template: TemplateRef<any>, alunoId: number) {
    this.alunosProfessores(template, alunoId);
  }

  closeModal() {
    this.modalRef.hide();
  }

  alunosProfessores(template: TemplateRef<any>, id: number) {
    this.spinner.show();
    this.alunoService.getByDisciplinaId(id)
      .pipe(takeUntil(this.unsubscriber))
      .subscribe((alunos: Aluno[]) => {
        this.alunosProfs = alunos;
        this.modalRef = this.modalService.show(template);
      }, (error: any) => {
        this.toastr.error(`erro: ${error}`);
        console.log(error);
      }, () => this.spinner.hide()
    );
  }

  ngOnInit() {
    this.spinner.show();
    this.carregarProfessor();
  }

  carregarProfessor() {
    const profId = +this.route.snapshot.paramMap.get('id');
    this.professorService.getById(profId)
      .pipe(takeUntil(this.unsubscriber))
      .subscribe((professor: Professor) => {
        this.professorSelecionado = professor;
        this.titulo = 'Professor: ' + this.professorSelecionado.id;
        this.toastr.success('Professor carregado com Sucesso!');
      }, (error: any) => {
        this.toastr.error('Professor não carregados!');
        console.log(error);
      }, () => this.spinner.hide()
    );
  }

  voltar() {
    this.router.navigate(['/professores']);
  }

  ngOnDestroy(): void {
    this.unsubscriber.next();
    this.unsubscriber.complete();
  }

}
