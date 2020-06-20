import { JwksValidationHandler, ValidationParams } from 'angular-oauth2-oidc';

export class MyJwksValidationHandler extends JwksValidationHandler {
    async validateAtHash(params: ValidationParams): Promise<boolean> {
        return true;
    }
}