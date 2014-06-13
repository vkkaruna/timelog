var util = require('util');

describe('DeveloperTimeLog', function() {
    var ptor;
    beforeEach(function() {
        isAngularSite(true);
        ptor = protractor.getInstance();

    })

    it('should be able to login by a developer', function() {
        ptor.get('/#/');
        var userName = ptor.findElement(protractor.By.id('username'));

        expect(userName.getText()).toEqual('');
        userName.sendKeys('Karuna');
        var password = ptor.findElement(protractor.By.id('password'));

        expect(password.getText()).toEqual('');
        password.sendKeys('Test1234');


        var loginButton = element(By.css('.btn'));
        loginButton.click();

    });

    it('should be able select project', function() {
        var projectSelect = ptor.findElement(protractor.By.id('project'));
        expect(projectSelect.getText()).not.toBe(null);
    });

    it('should be able logout', function() {
        var logoutLink = ptor.findElement(protractor.By.linkText('Logout'));
        logoutLink.click();
    });
});

describe('ClientTimeSheetView', function() {
    var ptor;
    beforeEach(function() {
        isAngularSite(true);
        ptor = protractor.getInstance();

    })

    it('should be able to login by client', function() {
        ptor.get('/#/');
        var userName = ptor.findElement(protractor.By.id('username'));

        expect(userName.getText()).toEqual('');
        userName.sendKeys('Sebastian');
        var password = ptor.findElement(protractor.By.id('password'));

        expect(password.getText()).toEqual('');
        password.sendKeys('Test1234');


        var loginButton = element(By.css('.btn'));
        loginButton.click();

    });

    it('should be able select project', function() {
        var projectSelect = ptor.findElement(protractor.By.id('project'));
        expect(projectSelect.getText()).not.toBe(null);
    });

    it('should be able logout', function() {
        var logoutLink = ptor.findElement(protractor.By.linkText('Logout'));
        logoutLink.click();
    });
});
