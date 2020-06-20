import { Component } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { authCodeFlowConfig } from './auth-code-flow.config';
import { Router } from '@angular/router';
import { MyJwksValidationHandler } from './MyJwksValidationHandler';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  title = 'EmployeeUI';
  constructor(private oauthService: OAuthService,
    private router: Router) {
      // this.oauthService
      // .events
      // .subscribe((res: { type: any; }) => {
      //   switch (res.type) {
      //     case 'token_received':
      //       this.router.navigate(['employees']);
      //       break;
      //     default:
      //       break;
      //   }
      // });
      
      // if(!this.oauthService.hasValidAccessToken()){
      //   this.oauthService.initCodeFlow();
      //   this.oauthService.configure(authCodeFlowConfig);
      //   this.oauthService.loadDiscoveryDocumentAndTryLogin();
      // }
  }
}