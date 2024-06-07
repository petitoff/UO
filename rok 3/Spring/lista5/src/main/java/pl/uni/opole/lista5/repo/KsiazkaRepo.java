package pl.uni.opole.lista5.repo;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import pl.uni.opole.lista5.model.Autor;
import pl.uni.opole.lista5.model.Ksiazka;

import java.util.List;

@Repository
public interface KsiazkaRepo extends JpaRepository<Ksiazka,Integer> {
    List<Ksiazka>findByTytulEquals(String title);
}
