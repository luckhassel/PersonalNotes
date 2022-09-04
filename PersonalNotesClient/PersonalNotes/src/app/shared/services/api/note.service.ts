import { DatePipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { endpoints } from 'src/app/data/constants/backend-constants';
import { CreateUpdateNote, Note } from 'src/app/data/models/note';

@Injectable({
  providedIn: 'root'
})
export class NoteService {

  constructor(private readonly http: HttpClient, private datePipe: DatePipe) { }

  createNote(body: CreateUpdateNote): Observable<any>{
    return this.http.post<any>(endpoints.baseApiUrl + endpoints.note.createNote, {
      ...body
    });
  }

  getNote(noteId: string): Observable<Note>{
    return this.http.get<any>(endpoints.baseApiUrl + endpoints.note.getNote + noteId);
  }

  listNote(): Observable<Note[]>{
    const currentDate = this.datePipe.transform(new Date(), "M/d/yy, h:mm a");
    return this.http.get<any>(endpoints.baseApiUrl + endpoints.note.getNote + "?initialDate=" + currentDate);
  }

  updateNote(body: CreateUpdateNote, noteId: string): Observable<any>{
    return this.http.put<any>(endpoints.baseApiUrl + endpoints.note.updateNote + noteId, {
      ...body
    });
  }
}
