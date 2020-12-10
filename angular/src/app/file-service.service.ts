import { HttpClient, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FileService {
  attacmentId : number = 0;
  constructor(public http : HttpClient) { }
  public UploadFiles (data: FormData){
    return this.http.post("https://localhost:44310/File/Create",data);
  }

  public DownloadFile(fileName: string){
    
    return this.http.request(new HttpRequest(
  'GET',
  `https://localhost:44310/File/Download?fileName=${fileName}`,
  null,
  {
    responseType: 'blob'
  }
));


}



  
}
