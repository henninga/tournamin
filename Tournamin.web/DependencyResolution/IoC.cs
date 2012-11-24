using Raven.Client;
using Raven.Client.Embedded;
using StructureMap;
namespace Tournamin.web {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                        
                                    });
                            x.For<IDocumentStore>().Singleton().Use(y =>
                            {
                                var store = new EmbeddableDocumentStore();
                                //store.UseEmbeddedHttpServer = true;
                                
                                store.Initialize();
                                return store;
                            });
                            x.For<IDocumentSession>().Use(y => y.GetInstance<IDocumentStore>().OpenSession());
                            //                x.For<IExample>().Use<Example>();
                        });
            return ObjectFactory.Container;
        }
    }
}