package pl.opole.uni.lista2.model;

import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;

import java.util.List;
import java.util.Objects;

@Entity
public class Dzial {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer dzialID;
    private String symbol;
    private String nazwa;
    @JsonIgnore
    @OneToMany(mappedBy = "dzial")
    private List<Uzytkownik> uzytkownicy;

    public Integer getDzialID() {
        return dzialID;
    }

    public void setDzialID(Integer dzialID) {
        this.dzialID = dzialID;
    }

    public String getSymbol() {
        return symbol;
    }

    public void setSymbol(String symbol) {
        this.symbol = symbol;
    }

    public String getNazwa() {
        return nazwa;
    }

    public void setNazwa(String nazwa) {
        this.nazwa = nazwa;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Dzial dzial = (Dzial) o;
        return Objects.equals(dzialID, dzial.dzialID);
    }

    @Override
    public int hashCode() {
        return Objects.hash(dzialID);
    }
}
