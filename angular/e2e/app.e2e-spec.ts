import { AspnetboilerplateDemoTemplatePage } from './app.po';

describe('AspnetboilerplateDemo App', function() {
  let page: AspnetboilerplateDemoTemplatePage;

  beforeEach(() => {
    page = new AspnetboilerplateDemoTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
