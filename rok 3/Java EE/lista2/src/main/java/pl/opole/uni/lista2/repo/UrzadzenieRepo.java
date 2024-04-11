package pl.opole.uni.lista2.repo;

import jakarta.persistence.criteria.CriteriaBuilder;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;
import pl.opole.uni.lista2.model.Dzial;
import pl.opole.uni.lista2.model.RodzajUrzadzenia;
import pl.opole.uni.lista2.model.Urzadzenie;

import java.util.List;

@Repository
public interface UrzadzenieRepo extends JpaRepository<Urzadzenie, Integer> {
    @Query(value = "SELECT u FROM Urzadzenie u WHERE u.rodzajUrzadzenia.rodzajUrzadzeniaID=1")
    List<Urzadzenie> findPrinterJPQL();

    @Query(value = "SELECT * FROM urzadzenie WHERE rodzaj=1",nativeQuery = true)
    List<Urzadzenie> findPrinterSQL();

    @Query(value = "SELECT u FROM Urzadzenie u WHERE u.producent.producentID!=2")
    List<Urzadzenie> findNotSonyJPQL();

    @Query(value = "SELECT * FROM urzadzenie WHERE producent!=2",nativeQuery = true)
    List<Urzadzenie> findNotSonySQL();
}
