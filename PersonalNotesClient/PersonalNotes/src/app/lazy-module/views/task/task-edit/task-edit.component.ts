import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NoteService } from 'src/app/shared/services/api/note.service';
import { UserService } from 'src/app/shared/services/api/user.service';
import { SnackbarService } from 'src/app/shared/services/components/snackbar/snackbar.service';

@Component({
  selector: 'app-task-edit',
  templateUrl: './task-edit.component.html',
  styleUrls: ['./task-edit.component.css']
})
export class TaskEditComponent implements OnInit {

  form: UntypedFormGroup;
  documentId = '';

  constructor(private fb: UntypedFormBuilder, 
    private readonly routerService: Router, 
    private readonly noteService: NoteService,
    private readonly queryService: ActivatedRoute,
    private readonly snackBarService: SnackbarService) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      subject: ['', [Validators.required]],
      description: ['', [Validators.required]],
      startDate: ['', [Validators.required]],
      endDate: ['', [Validators.required]]
    });

    this.queryService.params.subscribe((params) => {
      this.documentId = params['id'];
    });

    if(this.documentId){
      this.noteService.getNote(this.documentId).subscribe((message) => {
        this.form.controls['subject'].setValue(message.subject);
        this.form.controls['description'].setValue(message.description);
        this.form.controls['startDate'].setValue(message.startDate);
        this.form.controls['endDate'].setValue(message.endDate);
      }, 
      (error) => {
        this.snackBarService.openErrorSnackBar(error.error);
      })
    }
  }

  onSubmit(){
    if(this.documentId){
      this.noteService.updateNote({
        subject: this.form.value.subject,
        description: this.form.value.description,
        startDate: this.form.value.startDate,
        endDate: this.form.value.endDate
      }, this.documentId).subscribe((message) => {
        this.snackBarService.openSuccessSnackBar("Task Updated");
        this.routerService.navigateByUrl('task');
      },
      (error) => {
        this.snackBarService.openErrorSnackBar(error.error);
      })
    }
    else{
      this.noteService.createNote({
        subject: this.form.value.subject,
        description: this.form.value.description,
        startDate: this.form.value.startDate,
        endDate: this.form.value.endDate
      }).subscribe((message) => {
        this.snackBarService.openSuccessSnackBar("Task Created");
        this.routerService.navigateByUrl('task');
      },
      (error) => {
        this.snackBarService.openErrorSnackBar(error.error);
      })
    }

  }

  invalidForm(){
    return this.form.invalid;
  }

  back(){
    this.routerService.navigateByUrl('/task');
  }

}
