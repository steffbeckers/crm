import { CRMTemplatePage } from './app.po';

describe('CRM App', function() {
  let page: CRMTemplatePage;

  beforeEach(() => {
    page = new CRMTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
