import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Note } from 'src/app/data/models/note';
import { NoteService } from 'src/app/shared/services/api/note.service';
import { SnackbarService } from 'src/app/shared/services/components/snackbar/snackbar.service';

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

@Component({
  selector: 'app-task',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css']
})
export class TaskComponent implements OnInit {

  dataSource: Note[] = [];

  constructor(private readonly noteService: NoteService, private readonly routerService: Router, private readonly snackBarService: SnackbarService) { }

  ngOnInit(): void {
    this.noteService.listNote().subscribe((message) => {
      this.dataSource = message;
    }, 
    (error) => {
      this.snackBarService.openErrorSnackBar(error.error);
    });
  }

  displayedColumns: string[] = ['startDate', 'endDate', 'subject', 'description'];

  new(){
    this.routerService.navigateByUrl('task/create');
  }

  edit(event: Note){
    this.routerService.navigateByUrl(`task/update/${event.id}`)
  }

}
