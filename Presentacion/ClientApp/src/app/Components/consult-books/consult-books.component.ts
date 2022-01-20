import { Component, OnInit } from '@angular/core';
import { Book } from 'src/app/Elements/models/book';
import { BookService } from 'src/app/Elements/services/Book.service';
import { SignalRService } from 'src/app/Elements/services/SignalR.service';

@Component({
  selector: 'app-consult-books',
  templateUrl: './consult-books.component.html',
  styleUrls: ['./consult-books.component.css']
})
export class ConsultBooksComponent implements OnInit {

  books: Book[];
  book: Book;
  
  BOOKS: Book[];
  page = 1;
  pageSize = 3;
  collectionSize = 0;


  constructor(
    private service: BookService,
    private signalService: SignalRService
  ) { }

  ngOnInit() {
    this.book= new Book();
    
    this.get();

    this.signalService.signalReceived
    .subscribe((signal:Book) => {
      this.get();
    });
  }
  get() {
    this.service.get().subscribe(result => {
      this.BOOKS = result;
      this.collectionSize = this.BOOKS.length;

      this.books = this.BOOKS.map((servicios, i) => ({
        id: i + 1,
        ...servicios,
      })).slice(
        (this.page - 1) * this.pageSize,
        (this.page - 1) * this.pageSize + this.pageSize
      );
    });
  }
  put() {
    this.service.put(this.book).subscribe(result => {
      this.books = result;
    });
  }
  delete(codBook: number) {
    this.service.delete(codBook).subscribe(result => {
      
    });
  }

}
